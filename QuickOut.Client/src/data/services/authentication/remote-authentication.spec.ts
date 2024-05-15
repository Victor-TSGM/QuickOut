import { HttpStatusCode } from "@/data/protocols/http/HttpResponse";
import { RemoteAuthentication } from "./RemoteAuthentication"
import { HttpPostClientSpy } from "@/data/test/mock-http-client"
import { InvalidCredentialsError } from "@/domain/errors/InvalidCredentialsError";
import { MockAccountModel, MockAuthentication } from "@/domain/test/mock-account";
import { faker, ur } from '@faker-js/faker';
import { UnespectedError } from "@/domain/errors/UnespectedError";
import { AccountModel } from "@/domain/models/AccountModel";
import { emit } from "process";
import { AuthenticationParams } from "@/domain/interfaces/IAuthentication";

type SutTypes = {
  sut: RemoteAuthentication
  httpPostClientSpy: HttpPostClientSpy<AuthenticationParams, AccountModel>
}

const makeSut = (url: string = faker.internet.url()): SutTypes => {
  const httpPostClientSpy = new HttpPostClientSpy<AuthenticationParams, AccountModel>()
  const sut = new RemoteAuthentication(url, httpPostClientSpy)
  return {
    sut,
    httpPostClientSpy
  }
}

describe('RemoteAuthentication', () => {
  test('Should call HttpPostClient with correct URL', async () => {
    const url = faker.internet.url()
    const {sut, httpPostClientSpy} = makeSut(url);
    await sut.auth(MockAuthentication())
    expect(httpPostClientSpy.url).toBe(url);
  })

  test('Should call HttpPostClient with correct body', async () => {
    const {sut, httpPostClientSpy} = makeSut();
    const authParams = MockAuthentication();
    await sut.auth(authParams)
    expect(httpPostClientSpy.body).toEqual(authParams)
  })

  test('Should throw InvalidCredentialsError error if httpPostClient returns 401', async () => {
    const {sut, httpPostClientSpy} = makeSut();
    httpPostClientSpy.response = {
      statusCode: HttpStatusCode.unauthorized
    }
    const authParams = MockAuthentication();
    const promise = sut.auth(authParams)
    await expect(promise).rejects.toThrow(new InvalidCredentialsError);
  })

  test('Should throw unespectedError error if httpPostClient returns 400', async () => {
    const {sut, httpPostClientSpy} = makeSut();
    httpPostClientSpy.response = {
      statusCode: HttpStatusCode.badRequest
    }
    const authParams = MockAuthentication();
    const promise = sut.auth(authParams)
    await expect(promise).rejects.toThrow(new UnespectedError);
  })

  test('Should throw unespectedError error if httpPostClient returns 404', async () => {
    const {sut, httpPostClientSpy} = makeSut();
    httpPostClientSpy.response = {
      statusCode: HttpStatusCode.notFound
    }
    const authParams = MockAuthentication();
    const promise = sut.auth(authParams)
    await expect(promise).rejects.toThrow(new UnespectedError);
  })

  test('Should throw unespectedError error if httpPostClient returns 500', async () => {
    const {sut, httpPostClientSpy} = makeSut();
    httpPostClientSpy.response = {
      statusCode: HttpStatusCode.serverError
    }
    const authParams = MockAuthentication();
    const promise = sut.auth(authParams)
    await expect(promise).rejects.toThrow(new UnespectedError);
  })

  test('Should throw unespectedError error if httpPostClient returns 500', async () => {
    const {sut, httpPostClientSpy} = makeSut();
    const httpResult = MockAccountModel();
    httpPostClientSpy.response = {
      statusCode: HttpStatusCode.ok,
      body: httpResult
    }
    const authParams = MockAuthentication();
    const account = await sut.auth(authParams)
    expect(account).toEqual(httpResult);
  })

})