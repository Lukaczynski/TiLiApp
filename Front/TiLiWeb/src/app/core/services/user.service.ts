import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { User } from '@core/models';
import { ApiRoutes } from '@core/constants/indes';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<User[]>(`${environment.apiUrl}${ApiRoutes.BASE_URL}${ApiRoutes.ACCOUNTS}`);
    }

    getById(id: string) {
        return this.http.get<User>(`${environment.apiUrl}${ApiRoutes.BASE_URL}${ApiRoutes.ACCOUNTS}/${id}`);
    }
}