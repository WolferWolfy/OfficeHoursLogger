//
//  LogEntryViewController.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 24/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import UIKit

class LogEntryViewController: BaseViewController {

    @IBOutlet weak var nameLabel: UITextField!
    
    @IBOutlet weak var directionSegmentedControl: UISegmentedControl!
    
    @IBOutlet weak var timePicker: UIDatePicker!
    
    @IBOutlet weak var datePicker: UIDatePicker!
    
    var entry: LogEntry?
    
    var isNewScenario = true
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
        
        if let entry = entry {
            setupView(entry)
        }
        else {
            
        }
    }
    
    func setupView(entry: LogEntry) {
        
        nameLabel.text = isNewScenario ? nil : entry.name
        directionSegmentedControl.selectedSegmentIndex = entry.direction == EntryDirection.Entry ? 0 : 1
        timePicker.date = entry.dateTime
        datePicker.date = entry.dateTime
    }
    
    
    @IBAction func saveButtonTapped(sender: AnyObject) {
        
        
        let direction = directionSegmentedControl.selectedSegmentIndex == 0 ? EntryDirection.Entry : EntryDirection.Exit
        
        var name = "Empty Entry Name"
        
        if let l = nameLabel.text {
            name = l
        }
        
        if isNewScenario {
        // save entry
            let newEntry = LogEntry(id: 0, name: name, direction: direction, dateTime: composeDateTime())
            repository.addEntry(newEntry)
        }
        else {
            // update entry
            let updateEntry = LogEntry(id: entry!.id, name: name, direction: direction, dateTime: composeDateTime())
            repository.updateEntry(updateEntry)
        }
        
        navigationController?.popViewControllerAnimated(true)
    }
    
    func composeDateTime() -> NSDate {
        let dateComp = datePicker.date.dateComponent()
        let timeComp = timePicker.date.timeComponent()
        
        let dateTime = NSDate.from(dateComp.year, month: dateComp.month, day: dateComp.day, hour: timeComp.hour, minute: timeComp.minute, second: timeComp.second)
        return dateTime
        
    }

}
