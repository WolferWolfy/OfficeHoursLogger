//
//  RepositoryManager.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 03/06/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import Foundation



class RepositoryManager {

    static let sharedInstance = RepositoryManager()
    
    let repository: OfficeHoursRepositoryProtocol
    
    private init() {
        
        repository = MockRepository()
    }
}