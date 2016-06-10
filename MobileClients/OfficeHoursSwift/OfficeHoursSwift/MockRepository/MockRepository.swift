//
//  MockRepository.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 24/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import Foundation

class MockRepository: OfficeHoursRepositoryProtocol{
    
    init() {
        
    }
    
    func addEntry(logEntry: LogEntry) -> Void {
        
        var maxId = 0;
        MockDataProvider.sharedInstance.userEntries.forEach { (entry) in
            maxId = entry.id > maxId ? entry.id : maxId
        }
        
        logEntry.id = maxId + 1;
        
        MockDataProvider.sharedInstance.userEntries.append(logEntry)
    }
    
    func findEntryById(id: Int) -> LogEntry? {
        
        var logEntry : LogEntry?
        MockDataProvider.sharedInstance.userEntries.forEach { (entry) in
            if (entry.id == id) {
                logEntry = entry
            }
        }
        
        return logEntry
    }
    
    func findAllMonth() -> [Month]? {
        
        return MockDataProvider.sharedInstance.entriesToMonths(MockDataProvider.sharedInstance.userEntries)
    }
    
    func updateEntry(logEntry: LogEntry) -> Void {
        
        if let entry = findEntryById(logEntry.id) {
            entry.dateTime = logEntry.dateTime
            entry.direction = logEntry.direction
            entry.name = logEntry.name
        }
    }
    
    func deleteEntryById(id: Int) -> Void {
        
        MockDataProvider.sharedInstance.userEntries =
            MockDataProvider.sharedInstance.userEntries.filter({ $0.id != id })
    }
    
    func findDay(date: NSDate) -> Day {
        
        let searhedDateComp = date.dateComponent()
        
        if let months = findAllMonth() {
            
            let searchedMonth = months.filter({ (m) -> Bool in
                let dateComp = m.days.first?.date?.dateComponent()
                return (searhedDateComp.year == dateComp?.year && searhedDateComp.month == dateComp?.month)
            }).first
            
            if let sm = searchedMonth {
                let days = sm.days.filter({ (d) -> Bool in
                        let dateComp = d.date?.dateComponent()
                        return (searhedDateComp.day == dateComp?.day)
                })
                
                if let day = days.first {
                    day.logEntries.sortInPlace({ (entry1, entry2) -> Bool in
                        entry1.dateTime.compare(entry2.dateTime) == NSComparisonResult.OrderedAscending
                    })
                    return day
                }
            }
            
            
        }
        return Day(entries: [LogEntry]())
    }
    
    
}