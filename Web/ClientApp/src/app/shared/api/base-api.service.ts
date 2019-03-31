import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export class BaseApiService {
  private baseUrl;

  constructor(
    public apiName: string,
    public http: HttpClient
  ) {
    this.baseUrl = '/api/' + apiName + '/';
  }

  public get<T>(url: string): Observable<T> {
    return this.http.get<T>(this.baseUrl + url, { withCredentials: true });
  }

  public post<T>(url: string, data: any = {}): Observable<T> {
    return this.http.post<T>(this.baseUrl + url, data, { withCredentials: true });
  }
}
