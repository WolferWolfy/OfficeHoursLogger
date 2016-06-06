//
//  MockDataProvider.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 24/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import Foundation

private let mockData = MockDataProvider()

class MockDataProvider {
    class var sharedInstance: MockDataProvider {
        return mockData
    }
    static let sharedInstance2 = MockDataProvider()
    
    init() {
        userEntries = [LogEntry]()
        userEntries = createUserEntries()
    }

    var userEntries : [LogEntry]
    
    func createUserEntries() -> [LogEntry] {
        
        return [LogEntry(id: 1, name: "Arrive", direction: EntryDirection.Entry,
                    dateTime: NSDate.from(2016, month: 1, day: 5, hour: 9, minute: 10, second: 0)),
                LogEntry(id: 2, name: "Break start", direction: EntryDirection.Exit,
                    dateTime: NSDate.from(2016, month: 1, day: 5, hour: 11, minute: 30, second: 0)),
                LogEntry(id: 3, name: "Break end", direction: EntryDirection.Entry,
                    dateTime: NSDate.from(2016, month: 1, day: 5, hour: 11, minute: 55, second: 0)),
                LogEntry(id: 4, name: "Depart", direction: EntryDirection.Exit,
                    dateTime: NSDate.from(2016, month: 1, day: 5, hour: 17, minute: 50, second: 0)),
                
                LogEntry(id: 5, name: "Arrive", direction: EntryDirection.Entry,
                    dateTime: NSDate.from(2016, month: 2, day: 1, hour: 9, minute: 00, second: 0)),
                LogEntry(id: 6, name: "Break start", direction: EntryDirection.Exit,
                    dateTime: NSDate.from(2016, month: 2, day: 1, hour: 11, minute: 30, second: 0)),
                LogEntry(id: 7, name: "Break end", direction: EntryDirection.Entry,
                    dateTime: NSDate.from(2016, month: 2, day: 1, hour: 12, minute: 5, second: 0)),
                LogEntry(id: 8, name: "Depart", direction: EntryDirection.Exit,
                    dateTime: NSDate.from(2016, month: 2, day: 1, hour: 17, minute: 45, second: 0)),
                
                LogEntry(id: 9, name: "Arrive", direction: EntryDirection.Entry,
                    dateTime: NSDate.from(2016, month: 2, day: 2, hour: 8, minute: 30, second: 0)),
                LogEntry(id: 10, name: "Break start", direction: EntryDirection.Exit,
                    dateTime: NSDate.from(2016, month: 2, day: 2, hour: 11, minute: 25, second: 0)),
                LogEntry(id: 11, name: "Break end", direction: EntryDirection.Entry,
                    dateTime: NSDate.from(2016, month: 2, day: 2, hour: 12, minute: 10, second: 0)),
                LogEntry(id: 12, name: "Break start", direction: EntryDirection.Exit,
                    dateTime: NSDate.from(2016, month: 2, day: 2, hour: 14, minute: 0, second: 0)),
                LogEntry(id: 13, name: "Break end", direction: EntryDirection.Entry,
                    dateTime: NSDate.from(2016, month: 2, day: 2, hour: 14, minute: 15, second: 0)),
                LogEntry(id: 14, name: "Depart", direction: EntryDirection.Exit,
                    dateTime: NSDate.from(2016, month: 2, day: 2, hour: 18, minute: 10, second: 0))
                ]
    }
    
    func entriesToMonths(entries: [LogEntry]) -> [Month]? {
        
        //Here I’m creating the calendar instance that we will operate with:
        let calendar = NSCalendar.init(calendarIdentifier: NSCalendarIdentifierGregorian)
        //Now asking the calendar what month are we in today’s date:
   /*     let currentMonthInt = (calendar?.component(NSCalendarUnit.Month, fromDate: NSDate()))!
        //Now asking the calendar what year are we in today’s date:
        let currentYearInt = (calendar?.component(NSCalendarUnit.Year, fromDate: NSDate()))!
   */
        var yearMonthDictionary: [Int: [Int:[Int:Day]]] =  [Int: [Int:[Int:Day]]]()
        
        entries.forEach { (entry) in

            //Now asking the calendar what month are we in today’s date:
            //Now asking the calendar what year are we in today’s date:
            let currentYearInt = (calendar?.component(NSCalendarUnit.Year, fromDate: entry.dateTime))!
            let currentMonthInt = (calendar?.component(NSCalendarUnit.Month, fromDate: entry.dateTime))!
            let currentDayInt = (calendar?.component(NSCalendarUnit.Day, fromDate: entry.dateTime))!
            
            if var monthsDict = yearMonthDictionary[currentYearInt] {
              //  addToMonthDict(entry, monthsDict: monthsDict)
                
                
                if var aMonthDict = monthsDict[currentMonthInt] {
                    let day = dayToAdd(currentDayInt, daysDict: aMonthDict)
                    day.logEntries.append(entry)
                    
                    aMonthDict[currentDayInt] = day
                    monthsDict[currentMonthInt] =  aMonthDict
                    
                }
                else {
                    var entries = [LogEntry]()
                    entries.append(entry)
                    var newMD = [Int:Day]()
                    let day = dayToAdd(currentDayInt, daysDict: newMD)
                    day.logEntries.append(entry)
                    newMD[currentDayInt] = day
                    
                    monthsDict[currentMonthInt] =  newMD
            
                }

                yearMonthDictionary[currentYearInt] = monthsDict
            }
            else {
        
                var monthsDict = [Int:[Int:Day]]()
                
              //  addToMonthDict(entry, monthsDict: monthsDict)

                if let aMonthDict = monthsDict[currentMonthInt] {
                    let day = dayToAdd(currentDayInt, daysDict: aMonthDict)
                    day.logEntries.append(entry)
                    
                }
                else {
                    var entries = [LogEntry]()
                    entries.append(entry)
                    var newMD = [Int:Day]()
                    let day = dayToAdd(currentDayInt, daysDict: newMD)
                    day.logEntries.append(entry)
                    newMD[currentDayInt] = day
                    
                    monthsDict[currentMonthInt] =  newMD
                    
                }
              /*  if var aMonthDict = monthsDict[currentYearMonth] {
                    aMonthDict.append(entry)
                    
                }
                else {
                    var entries = [LogEntry]()
                    entries.append(entry)
                    monthsDict[currentYearMonth] = entries
                }*/
                yearMonthDictionary[currentYearInt] = monthsDict
            }
        }
        
        var months = [Month]()
        
        yearMonthDictionary.values.forEach { (monthsDict :[Int : [Int:Day]]) in
            // foreach every year
            
 

            monthsDict.values.forEach({ (dayDict) in
                let aMonth = Month()
                dayDict.values.forEach({ (day) in
                    aMonth.days.append(day)

                })
                months.append(aMonth)
        })
            


            
        }
        
        return months
    }
    
    private func dayToAdd(dayNumber: Int, daysDict: [Int:Day]) -> Day {
        
        if let aDay = daysDict[dayNumber] {
            return aDay
           // aDay.logEntries.append(entry)
        }
        else {
            let newDay = Day(entries: [LogEntry]())
            return newDay
        }
    }
    /*
    func addToMonthDict(entry : LogEntry, monthsDict: [Int: [LogEntry]]) -> Void {
        let calendar = NSCalendar.init(calendarIdentifier: NSCalendarIdentifierGregorian)
     
        let currentYearMonth = (calendar?.component(NSCalendarUnit.Month, fromDate: entry.dateTime))!
        
        if var aMonthDict = monthsDict[currentYearMonth] {
            aMonthDict.append(entry)
            
        }
        else {
            var entries = [LogEntry]()
            entries.append(entry)
            monthsDict[currentYearMonth] = entries
        }
 
    }
 */
}