import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Category, GetQuestions } from '../Module/Quize';

@Injectable({
  providedIn: 'root'
})
export class QuestionsListService {
  public API = 'https://localhost:44359';
  public GetQuestionList_API = `${this.API}/GetQuestionList`;
  constructor(private _httpClient:HttpClient) {}
  GetQuestionList(params: Category): Observable<GetQuestions> {
    return this._httpClient.post<any>(`${this.GetQuestionList_API}`, params);
  }
}
