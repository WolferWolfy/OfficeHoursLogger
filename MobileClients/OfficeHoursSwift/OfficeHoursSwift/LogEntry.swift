//
//  LogEntry.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 25/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import Foundation

class LogEntry {
    
    var id : Int
    var name : String
    var direction : EntryDirection
    var dateTime: NSDate
    
    init(id: Int, name: String, direction: EntryDirection, dateTime: NSDate) {
        self.id = id
        self.name = name
        self.direction = direction
        self.dateTime = dateTime
    }
}