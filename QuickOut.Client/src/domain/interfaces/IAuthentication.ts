import { AccountModel } from "../models/AccountModel"

export type AuthenticationParams = {
  email: string
  password: string
}

export interface IAuthentication {
  auth(params: AuthenticationParams): Promise<AccountModel>
}