export interface Category {
    readonly Categoryid: number;
    readonly CategoryName: string;
  }
  export interface GetQuestions {
    readonly questions: Questions[];
  }
  export interface Questions {
    readonly quesntionId: number;
    readonly questionname: string;
    readonly options: Options[];
    readonly answers: Answers[];
  }
  export interface Options {
    readonly optionid: number;
    readonly optionname: string;
  }
  export interface Answers {
    readonly answerid: number;
    readonly asnwertext: string;
  }

  