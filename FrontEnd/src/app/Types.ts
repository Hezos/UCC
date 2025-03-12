export interface Event
{
  id: string;
  Occurrence: string;
  Description?: string;
  
}

export interface User
{
  id: string;
  Name: string;
  Password: string;
  events?: Array<Event>;
}
