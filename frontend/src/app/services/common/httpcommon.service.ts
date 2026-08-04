import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HttpcommonService {
   private http = inject(HttpClient); // 👈 Modern Injection syntax
  //private apiUrl = API_URL; // Swap with your API
 // GET: Fetch all resources
  getAll(apiUrl: string): Observable<any[]> {
    return this.http.get<any[]>(apiUrl).pipe(
      catchError(this.handleError)
    );
  }

  // GET: Fetch single resource by ID
  getById(apiUrl: string): Observable<any> {
    return this.http.get<any>(apiUrl).pipe(
      catchError(this.handleError)
    );
  }

  // POST: Create a new resource
  create(apiUrl: string, payload: any): Observable<any> {
    return this.http.post<any>(apiUrl, payload).pipe(
      catchError(this.handleError)
    );
  }

  // PUT: Update an entire existing resource
  update(apiUrl: string, payload: any): Observable<any> {
    return this.http.put<any>(apiUrl, payload).pipe(
      catchError(this.handleError)
    );
  }

  // DELETE: Remove a resource
  delete(apiUrl: string): Observable<void> {
    return this.http.delete<void>(apiUrl).pipe(
      catchError(this.handleError)
    );
  }

  // Centralized error handler
  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'An unknown error occurred!';
    if (error.error instanceof ErrorEvent) {
      // Client-side or network error
      errorMessage = `Client Error: ${error.error.message}`;
    } else {
      // Backend error code
      errorMessage = `Server Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(() => new Error(errorMessage));
  }
}
