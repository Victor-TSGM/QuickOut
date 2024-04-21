// --> Imports

import { type IBoilerplateService } from '@/domain/interfaces/IBoilerplateService'

export class ServicesDefinition {
  // --> Services Definition
  buildBoilerplateService: () => IBoilerplateService
}
