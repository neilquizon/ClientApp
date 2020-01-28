import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class MyRemoteService {
    //url to the api
    private dataUrl = 'https://localhost:5001/api/sampledata/';

    constructor(private http: HttpClient) { }

    getResponse(methodName) {
        return this.http.get(this.dataUrl + methodName);
    }

}
