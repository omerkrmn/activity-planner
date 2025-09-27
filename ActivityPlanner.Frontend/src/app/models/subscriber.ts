export interface CreateSubscriberDTO {
    "subscriberName": string,
    "subscriberSurname": string,
    "subscriberMail": string,
    "mailValidation": string,
    "attendanceStatus": number,
    "activityId": number,
    "note" : string
}
export interface CreateSubscriberResultDTO {

    "subscriberId": number,
    "subscriberName": string,
    "subscriberSurname": string,
    "subscriberMail": string,
    "mailValidation": string,
    "attendanceStatus": number,
    "activityId": number
    "note" : string
}
export interface DeleteSubscriberDTO {
    "activityId": number,
    "subscriberMail": string
}
export interface SubscriberCreateDTO {
    subscriberName: string;
    subscriberSurname: string;
    subscriberMail: string;
    mailValidation?: string; // optional
    attendanceStatus: AttendanceStatus;
    activityId: number;
    note?: string; // optional
}
export enum AttendanceStatus {
    Confirmed = 0,
    Unsure = 1
}
export interface SubscriberUpdateDTO {
  subscriberId: number;
  attendanceStatus: AttendanceStatus;
  activityId: number;
}