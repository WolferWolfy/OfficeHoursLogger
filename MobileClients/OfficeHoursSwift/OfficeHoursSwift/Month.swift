//
//  Month.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 30/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import Foundation

class Month {
    
    var days: [Day]
    
    var date: NSDate? {
        get {
            return days.first?.arrival
        }
    }
    
    var averageIn: TimeSpan {
        get {
            return calculateAverageIn()
        }
    }
    
    
    var outTime: TimeSpan {
        get {
            return calculateAverageOut()
        }
    }
    
    init() {
        
        self.days = [Day]()
    }
    
    init(days: [Day]) {
        
        self.days = days
    }
    
    private func calculateAverageIn() -> TimeSpan
    {
        
    var fullIn = TimeSpan()
    
        days.forEach { (day) in
            fullIn.addTimeSpan(day.inTime)
        }
        return TimeSpan( fullIn.totalSeconds /= days.count);
    }

    private func calculateAverageOut() -> TimeSpan
    {
        var fullOut = TimeSpan()
        
        days.forEach { (day) in
            fullOut.addTimeSpan(day.outTime)
        }
        return TimeSpan( fullOut.totalSeconds /= days.count);
    }

}
