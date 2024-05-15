import { HttpStatusCode } from "@/data/protocols/http/HttpResponse";
import { IHttpPostClient } from "@/data/protocols/http/post/IHttpPostClient";
import { InvalidCredentialsError } from "@/domain/errors/InvalidCredentialsError";
import { UnespectedError } from "@/domain/errors/UnespectedError";
import { Authentication, AuthenticationParams } from "@/domain/interfaces/Authentication";
import { AccountModel } from "@/domain/models/AccountModel";

export class RemoteAuthentication implements Authentication {
  constructor(
    private readonly url: string,
    private readonly httpPostClient: IHttpPostClient<AuthenticationParams, AccountModel>
    ) {
  }

  async auth(params: AuthenticationParams): Promise<AccountModel> {
    const httpResponse = await this.httpPostClient.post({
      url: this.url,
      body: params
    })

    switch(httpResponse.statusCode) {
      case HttpStatusCode.ok: return httpResponse.body;
      case HttpStatusCode.unauthorized: throw new InvalidCredentialsError();
      default: throw new UnespectedError();
    }
  }
}