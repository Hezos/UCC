export interface Event
{
  //Let MongoDB handle id!
  id: string;
  Title: string;
  Occurrence: string;
  Description?: string;
  UserId: string;
  Datacoder: number
}

export interface User
{
  id: string;
  Name: string;
  Password: string;
  //For events pass userid for the controller and get all events that way.
  JWT: string;
  Datacoder: number

}

export interface CryptingInfo
{
  Datacoder: number;
  Data: string;
}
