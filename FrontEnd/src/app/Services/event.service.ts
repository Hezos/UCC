import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Event } from '../Types';

@Injectable({
  providedIn: 'root'
})



//Allways ask UserId before executing, jwt comes from the user object
export class EventService {

  constructor() { }

  http = inject(HttpClient);

  getByUser(id: string, jwt: string) {
    return this.http.get<Array<Event>>(`https://localhost:7274/api/event/${id}`, {
      headers: {
        "Authorization": `Bearer ${jwt}` 
      }
    });
  }

  updateEvent(id: string, event: Event, jwt: string) {
    return this.http.put<Event>(`https://localhost:7274/api/event/${id}`, event, {
      headers: {
        "Authorization": `Bearer ${jwt}`
      }
    });
  }

  registerEvent(userid: string, event: Event, jwt: string) {
    event.UserId = userid;
    return this.http.post<Event>("https://localhost:7274/api/event", event, {
      headers: {
        "Authorization": `Bearer ${jwt}` 
      }
    });
  }

  deleteEvent(id: string, jwt: string) {
    return this.http.delete(`https://localhost:7274/api/event/${id}`, {
      headers: {
        "Authorization": `Bearer ${jwt}` 
      }
    });
  }

}
