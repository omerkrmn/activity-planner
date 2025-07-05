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
}