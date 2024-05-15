import { AuthenticationParams } from "../interfaces/IAuthentication";
import { AccountModel } from "../models/AccountModel";
import { faker } from "@faker-js/faker";

export const MockAuthentication = (): AuthenticationParams => ({
  email: faker.internet.email(),
  password: faker.internet.password()
})

export const MockAccountModel = (): AccountModel => ({
  accessToken: faker.string.uuid()
})