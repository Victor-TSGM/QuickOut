import { AxiosHttpClient } from "./AxiosHttpClient";
import axios from 'axios';
import { faker } from "@faker-js/faker";
import { HttpPostParams } from "@/data/protocols/http/post/IHttpPostClient";
import { FakeAxios } from "./test/FakeAxios";

jest.mock('axios');
const fakeAxios = axios as jest.Mocked<typeof axios>

type SutTypes = {
  sut: AxiosHttpClient,
  fakeAxios:jest.Mocked<typeof axios>
}

const makeSut = (): SutTypes => {
  const sut = new AxiosHttpClient()
  const fakeAxios = FakeAxios()
  return {
    sut,
    fakeAxios
  }
}

const mockPostRequest = ():HttpPostParams<any> => ({
  url: faker.internet.url(),
  body: {id: '1234', name: 'body'}
});

describe('AxiosHttpClient',  () => {
  test('should call axios with correct url', async () => {
    const request = mockPostRequest();
    const {sut, fakeAxios} = makeSut();
    await sut.post(request)
    // expect(fakeAxios) .toHaveBeenCalledWith(request.url)
  });

  test('should call axios with correct body', () => {
    const request = mockPostRequest();
    const {sut, fakeAxios} = makeSut();
    sut.post(request)
    expect(fakeAxios.post).toHaveBeenCalledWith(request.url, request.body)
  });

  test('should return the correct statusCode and Body', () => {
    const {sut, fakeAxios} = makeSut();
    const httpResponse =  sut.post(mockPostRequest())
    expect(httpResponse).toEqual(fakeAxios.post.mock.results[0].value)
  });
})