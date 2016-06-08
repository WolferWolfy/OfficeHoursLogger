//
//  TimeSpan.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 27/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import Foundation

struct TimeSpan {
    
    var totalSeconds: Int

    var hour: Int {
        get {
            return totalSeconds / 3600;
        }
    }
    
    var minute: Int {
        get {
            return (totalSeconds/60) % 60;
        }
    }
    
    var second: Int {
        get {
            return totalSeconds % 60;
        }
    }
    
    init() {
        self.init(hour: 0, minute: 0, second: 0)
    }
    
    init(hour: Int, minute: Int, second: Int) {
    
        self.totalSeconds = 60 * 60 * hour + 60 * minute + second
    }
    
    init(timeInterval: NSTimeInterval) {
        
        self.totalSeconds = Int(timeInterval)
    }
    
    init(seconds: Int) {
        
        self.totalSeconds = seconds
    }
    
    mutating func addTimeInterval(interval: NSTimeInterval) {
        //interval in seconds
        totalSeconds += Int(interval)
    }
    
    mutating func subtractTimeInterval(interval: NSTimeInterval) {
        //interval in seconds
        totalSeconds -= Int(interval)
    }
    
    mutating func addTimeSpan(timeSpan: TimeSpan) {
        totalSeconds += timeSpan.totalSeconds;
    }
    
    mutating func subtractTimeSpan(timeSpan: TimeSpan) {
        totalSeconds -= timeSpan.totalSeconds;
    }
    
    
    func toString() -> String {
        return String(format: "%02d:%02d:%02d", self.hour, self.minute, self.second)
    }
}