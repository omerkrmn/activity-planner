export interface CreateSubscriberDTO {
    "subscriberName": string,
    "subscriberSurname": string,
    "subscriberMail": string,
    "mailValidation": string,
    "attendanceStatus": number,
    "activityId": number
}
export interface CreateSubscriberResultDTO {

    "subscriberId": number,
    "subscriberName": string,
    "subscriberSurname": string,
    "subscriberMail": string,
    "mailValidation": string,
    "attendanceStatus": number,
    "activityId": number
}
export interface DeleteSubscriberDTO {
    "activityId": number,
    "subscriberMail": string
}