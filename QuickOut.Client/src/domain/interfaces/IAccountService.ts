export interface IAccountService {
  doLogin(email: string, password: string): Promise<void>
  doLogout():Promise<void>
}