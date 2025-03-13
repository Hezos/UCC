import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Event } from '../Types';

@Injectable({
  providedIn: 'root'
})



//Allways ask UserId before executing
export class EventService {

  constructor() { }

  http = inject(HttpClient);

  getByUser(id: string) {
    return this.http.get<Array<Event>>(`https://localhost:7274/api/event/${id}`);
  }

  updateEvent(id: string, event: Event) {
    return this.http.put<Event>(`https://localhost:7274/api/event/${id}`, event);
  }

  registerEvent(userid: string, event: Event) {
    event.UserId = userid;
    return this.http.post<Event>("https://localhost:7274/api/event", event);
  }

  deleteEvent(id: string) {
    return this.http.delete(`https://localhost:7274/api/event/${id}`);
  }

}
