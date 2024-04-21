import './styles/colors.css'
import './index.css'
import 'bootstrap/dist/css/bootstrap.css'

import * as React from 'react'
import { createRoot } from 'react-dom/client'
import { type ServicesDefinition } from '@/presentation/providers/ServicesDefinition'
import { App } from './app'
import { BoilerplateService } from '@/data/services/BoilerplateService'
// --> Imports

const services: ServicesDefinition = {
  // --> Services
  buildBoilerplateService: () => new BoilerplateService()
}

const container = document.getElementById('main')
const root = createRoot(container)

root.render(
  <React.StrictMode>
          <App />
  </React.StrictMode>
)
