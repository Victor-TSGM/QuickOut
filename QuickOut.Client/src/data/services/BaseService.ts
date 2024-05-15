export abstract class BaseService {
  public url = "http://localhost:5184"

  constructor(url: string ) {
    this.url += url;
  }
}