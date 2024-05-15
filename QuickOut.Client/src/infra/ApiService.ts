import axios from "axios";

export class ApiService {
  public static post(url: string, data?: any) {
    return axios.post(url, data).then(res => {
      return res.data
    })
  }
}