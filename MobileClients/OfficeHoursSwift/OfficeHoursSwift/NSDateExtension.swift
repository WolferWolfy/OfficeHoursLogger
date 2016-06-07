//
//  NSDateExtension.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 30/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import Foundation

extension NSDate
{
    convenience init(dateString:String) {
        let dateStringFormatter = NSDateFormatter()
        dateStringFormatter.dateFormat = "yyyy-MM-dd"
        dateStringFormatter.locale = NSLocale(localeIdentifier: "en_US_POSIX")
        let d = dateStringFormatter.dateFromString(dateString)!
        self.init(timeInterval:0, sinceDate:d)
    }
    
 /*   convenience init(year: Int, month: Int, day: Int, hour: Int, minute: Int, second: Int) {
        let dateStringFormatter = NSDateFormatter()
        dateStringFormatter.dateFormat = "yyyy-MM-dd"
        dateStringFormatter.locale = NSLocale(localeIdentifier: "en_US_POSIX")
        let d = dateStringFormatter.dateFromString(dateString)!
        self.init(timeInterval:0, sinceDate:d)
    }*/
    
    class func from(year:Int, month:Int, day:Int, hour: Int, minute: Int, second: Int) -> NSDate {
        let c = NSDateComponents()
        c.year = year
        c.month = month
        c.day = day
        c.hour = hour
        c.minute = minute
        c.second = second
        
        let gregorian = NSCalendar(identifier:NSCalendarIdentifierGregorian)
        let date = gregorian!.dateFromComponents(c)
        return date!
    }
    
    
    func toTimeString() -> String {
        
        let formatter = NSDateFormatter()
        formatter.dateFormat = "HH:mm:ss"
        
        let formattedString = formatter.stringFromDate(self)
        
        return formattedString
    }
    
    func toDateTimeString() -> String {

        let formatter = NSDateFormatter()
        formatter.dateFormat = "yyyy-MM-dd HH:mm:ss"
        
        let formattedString = formatter.stringFromDate(self)
        
        return formattedString
    }

    func toYearMonthString() -> String {
        
        let formatter = NSDateFormatter()
        formatter.dateFormat = "yyyy-MM"
        
        let formattedString = formatter.stringFromDate(self)
        
        return formattedString
    }
    
    func toDateString() -> String {
        
        let formatter = NSDateFormatter()
        formatter.dateFormat = "yyyy-MM-dd"
        
        let formattedString = formatter.stringFromDate(self)
        
        return formattedString
    }
    
    func dateComponent()-> NSDateComponents {
        let calendar = NSCalendar.currentCalendar()
        let components = calendar.components([.Year, .Month, .Day], fromDate: self)
        return components
    }
    
    func timeComponent()-> NSDateComponents {
        let calendar = NSCalendar.currentCalendar()
        let components = calendar.components([.Hour, .Minute, .Second], fromDate: self)
        return components
    }
    
    
}