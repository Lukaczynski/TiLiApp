import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '@core/models';
import { environment } from '@environments/environment';
import { Token } from '@core/models'
import { ApiRoutes } from '@core/constants/indes';


@Injectable({ providedIn: 'root' })
export class AuthService {
    private currentAuthSubject: BehaviorSubject<Token>;
    public currentAuth: Observable<Token>;

    constructor(private http: HttpClient) {
        this.currentAuthSubject = new BehaviorSubject<Token>(JSON.parse(localStorage.getItem('auth')));
        this.currentAuth = this.currentAuthSubject.asObservable();
    }

    public get currentAuthValue(): Token {
        return this.currentAuthSubject.value;
    }

    login(username: string, password: string) {
        return this.http.post<any>(`${environment.apiUrl}${ApiRoutes.BASE_URL}/Auth/login`, { username, password })
            .pipe(map(auth => {
                // login successful if there's a jwt token in the response
                if (auth && auth.authToken) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('auth', JSON.stringify(auth));
                    this.currentAuthSubject.next(auth);
                }

                return auth;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('auth');
        this.currentAuthSubject.next(null);
    }
}