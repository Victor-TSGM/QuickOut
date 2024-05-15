import { HttpResponse } from "@/data/protocols/http/HttpResponse";
import { HttpPostParams } from "@/data/protocols/http/post/IHttpPostClient";
import { IHttpPostClient } from "@/data/protocols/http/post/IHttpPostClient";
import axios from "axios";

export class AxiosHttpClient implements IHttpPostClient<any, any> {
  async post(params: HttpPostParams<any>): Promise<HttpResponse<any>> {
    const httpResponse = await  axios.post(params.url, params.body)
    return {
      statusCode: httpResponse.status,
      body: httpResponse.data
    }
  }
}