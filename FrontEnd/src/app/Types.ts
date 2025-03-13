export interface Event
{
  id: string;
  Title: string;
  Occurrence: string;
  Description?: string;
  UserId: string;
}

export interface User
{
  id: string;
  Name: string;
  Password: string;
  //For events pass userid for the controller and get all events that way.
  JWT: string;

}
