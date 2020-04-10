import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Project } from '@core/models';
import { environment } from '@environments/environment';

@Injectable({ providedIn: 'root' })
export class ProjectService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<Project[]>(`${environment.apiUrl}/project`);
    }

    getById(id: number) {
        return this.http.get<Project>(`${environment.apiUrl}/project/${id}`);
    }
}