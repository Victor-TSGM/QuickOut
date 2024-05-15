import { IAccountService } from "@/domain/interfaces/IAccountService";
import { BaseService } from "../BaseService";
import { ApiService } from "@/infra/ApiService";

export class AccountService extends BaseService implements IAccountService {
  constructor() {
    super('/account')
  }

  async doLogin(email: string, password: string): Promise<void> {
    return await ApiService.post(this.url + `/login?email=${email}&password=${password}`).then(response => {
      return response.data
    })
  }

  async doLogout(): Promise<void> {
    return await ApiService.post(this.url + `/logout`).then(response => {
      return response.data
    })
  }
}