//
//  MonthCell.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 06/06/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import UIKit

class MonthCell: UITableViewCell {
    
    @IBOutlet weak var dateLabel: UILabel!
    
    @IBOutlet weak var averageInLabel: UILabel!
    
    @IBOutlet weak var averageOutLabel: UILabel!
    
    var date: NSDate?
    var averageIn: TimeSpan?
    var averageOut: TimeSpan?
    
}