//
//  OfficeHoursRepositoryProtocol.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 24/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import Foundation

protocol OfficeHoursRepositoryProtocol {

    func addEntry(logEntry: LogEntry) -> Void
    
    func findEntryById(id: Int) -> LogEntry?
    
    func findAllMonth() -> [Month]?
    
    func updateEntry(logEntry: LogEntry) -> Void
    
    func deleteEntryById(id: Int) -> Void
    
}