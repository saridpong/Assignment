import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { GetFileResponse } from '../model/response/get-file-response';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UploadFileService {
  constructor(private http: HttpClient, private route: Router) {}

  uploadFile(criteria: FormData): Observable<GetFileResponse> {
    return this.http.post<GetFileResponse>(
      environment.apiUrl + 'upload',
      criteria
    );
  }
}
