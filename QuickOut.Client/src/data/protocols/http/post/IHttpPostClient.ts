import { HttpResponse } from "../HttpResponse"

export type HttpPostParams<TRequest> = {
  url: string
  body?: TRequest
}

export interface IHttpPostClient<TRequest, TResponse> {
  post(params: HttpPostParams<TRequest>) : Promise<HttpResponse<TResponse>>
}