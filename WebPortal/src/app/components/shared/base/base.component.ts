import { Router } from '@angular/router'
import { AlertService } from '../../../services/alert.service'

export class BaseComponent {    
    constructor(private alertService: AlertService) {
    }
    getHttpErrorResponse(error: any){
        switch (error.status) {
            case 401:                                
              return this.alertService.ModalNotification(
                'Aviso','No se encontraron los accesos para realizar esta acción.','error')
                    .then((result) => { 
                        if (result.value) { 
                            localStorage.removeItem('api-token')
                            localStorage.removeItem('app-user')
                            window.location.replace('/login') 
                        }
                    })
            case 404:
              return this.alertService.ToasterNotification('Aviso','No fueron encontrados datos en esta operación.','info')
            case 500:
              return this.alertService.ToasterNotification('Error','Oops! Ha ocurrido un error.','error')
            case 403:
                return this.alertService.ModalNotification(
                    'Aviso','No se encontraron los accesos para realizar esta acción.','error')
                    .then((result) => { 
                        if (result.value) { 
                            localStorage.removeItem('api-token')
                            localStorage.removeItem('app-user')
                            window.location.replace('/login') 
                        }
                    })
            case 0:
                return this.alertService.ToasterNotification('Error','Oops! Ha ocurrido un error.','error')
            case undefined:
                return this.alertService.ToasterNotification('Error','Oops! Ha ocurrido un error.','error')
          }
    }
}