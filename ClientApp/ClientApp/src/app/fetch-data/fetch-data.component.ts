import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MyRemoteService } from '../app.myremoteservice';

@Component({
    selector: 'app-fetch-data',
    template: ` {{_responseMsg}}
                <p *ngFor="let myMethod of _myMethods">
                  <button (click)="getSomeData(myMethod)">
                  {{myMethod}}
                  </button>
                </p>`,

    providers: [MyRemoteService]
})


export class FetchDataComponent {
    _myMethods: Array<any>;
    _myDataService: MyRemoteService;
    _responseMsg: string;
    _status: number;

    // Since we are using a provider above we can receive 
    // an instance through a constructor.
    constructor(myDataService: MyRemoteService) {
        // Store local reference to MyDataService.
        this._myDataService = myDataService;
        // Add to collection of methods to render more buttons
        
        this._myMethods = ['ObjectActionResult', 'OkObjectActionResult', 'OkWithObjectActionResult', 'OkEmptyWithoutObject', 'CreatedActionResult'
            , 'CreatedAtActionActionResult'];
    }

    getSomeData(methodName) {
        this._myDataService.getResponse(methodName)
            // Subscribe to changes in the observable object
            // that is returned by getResponse.
            .subscribe(
                // You basically get three handlers.
                // 1. Handle successful data.
                data => {
                    this._responseMsg = JSON.stringify(data)
                },
                // 2. Handle error.
                error => {
                    this._responseMsg = error;
                    this._status = error.status;
                },
                // 3. Execute final instructions when successful.
                () => {
                    console.log("Finished")
                });
    }
}

