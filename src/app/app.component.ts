import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { QuestionsListService } from './demo/questions-list.service';
import { Category } from './Module/Quize';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  questionList = [];
  constructor(private  questionsListService:QuestionsListService,
    private httpClient: HttpClient) { 
  }
  ngOnInit(): void {
   // this.loadquestionList()
    const keyParams: Category = {
      Categoryid: 1,
      CategoryName: ""
    };
    this.questionsListService.GetQuestionList(keyParams).subscribe((resp: any) => {
      if (resp) {
        console.log(resp)
      }
      else {
      }
    });
  }
 
}
