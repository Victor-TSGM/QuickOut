import { type IBoilerplateService } from '@/domain/interfaces/IBoilerplateService'

export class BoilerplateService implements IBoilerplateService {
  helloWorld = (): string => {
    return 'Hello World'
  }
}
