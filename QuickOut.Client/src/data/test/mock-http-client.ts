import { HttpResponse, HttpStatusCode } from "../protocols/http/HttpResponse"
import { HttpPostParams, IHttpPostClient } from "../protocols/http/post/IHttpPostClient"

export class HttpPostClientSpy<TRequest, TResponse> implements IHttpPostClient<TRequest, TResponse> {
  url?: string
  body?: TRequest
  response: HttpResponse<TResponse> = {
    statusCode: HttpStatusCode.ok,
  }
  
  async post(params: HttpPostParams<TRequest>): Promise<HttpResponse<TResponse>> {
    this.url = params.url
    this.body = params.body
    return Promise.resolve(this.response)
  }
}