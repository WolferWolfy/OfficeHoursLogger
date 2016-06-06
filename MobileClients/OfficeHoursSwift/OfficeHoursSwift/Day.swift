//
//  Day.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 25/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import Foundation

class Day {
    
    var logEntries: [LogEntry]
    
    var date: NSDate? {
        get {
            return arrival
        }
    }
    
    var arrival: NSDate? {
        get {
            return logEntries.first?.dateTime// ?? NSDate()
        }
    }
    
    var departure: NSDate? {
        get {
            return logEntries.last?.dateTime// ?? NSDate()
        }
    }
    
    var inTime: TimeSpan {
        get {
            
            var inTime = TimeSpan(timeInterval: departure!.timeIntervalSinceDate(arrival!))
    
            inTime.subtractTimeSpan(outTime)
            
            return inTime
        }
    }
    
    
    var outTime: TimeSpan {
        get {
            return calculateOutTime()
        }
    }
    
    init(entries: [LogEntry]) {
        
        logEntries = entries
    }
    
    private func calculateOutTime() -> TimeSpan {
        
        var breakTime = TimeSpan()
        var lastExitTime : NSDate?
        
        logEntries.forEach { (entry) in
            
            if( entry.direction == EntryDirection.Exit && lastExitTime == nil ) {
               
                lastExitTime = entry.dateTime
            }
            if( entry.direction == EntryDirection.Entry && lastExitTime != nil ) {
                
                let delta = entry.dateTime.timeIntervalSinceDate(lastExitTime!)
                
                breakTime.addTimeInterval(delta)
                lastExitTime = nil
            }
        }
        
        return breakTime
    }
    
    
}
