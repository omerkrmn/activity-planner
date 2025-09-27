export interface Activity {
  id: number
  appUserId: string
  activityName: string
  activityDescription: string
  attendanceStatusConfirmedCount: number
  attendanceStatusUnsureCount: number
  createdAt: string
  lastRegistrationDate: string
  isActive: boolean
  country: string
  city: string
  activityFullAddress: string
}

export interface ActivityCreateRequest {
  activityName: string;
  activityDescription: string;
  lastRegistrationDate: string | Date;
}