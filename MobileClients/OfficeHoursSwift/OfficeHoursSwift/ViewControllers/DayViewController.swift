//
//  DayViewController.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 24/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import UIKit

class DayViewController: BaseViewController, UITableViewDelegate, UITableViewDataSource {
    
    var day: Day?
    
    var selectedEntry: LogEntry?
        
    @IBOutlet weak var tableView: UITableView!
    
    @IBOutlet weak var topStackLayout: UIStackView!
    @IBOutlet weak var arrivalLabel: UILabel!
    @IBOutlet weak var departureLabel: UILabel!
    @IBOutlet weak var inTimeLabel: UILabel!
    @IBOutlet weak var outTimeLabel: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        // Do any additional setup after loading the view.
    }
    

    override func viewWillAppear(animated: Bool) {
        if let searchDate = day?.date {
            day = repository.findDay(searchDate)
            self.tableView.reloadData()
            updateLabels()
        }
    }
    
    
    func updateLabels() {
        guard let theDay = day else {
            return
        }
        
        arrivalLabel.text = theDay.arrival?.toTimeString()
        departureLabel.text = theDay.departure?.toTimeString()
        inTimeLabel.text = theDay.inTime.toString()
        outTimeLabel.text = theDay.outTime.toString()
    }
    
    func tableView(tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return day?.logEntries.count ?? 0
    }
    
    func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
       /* let cell = EntryCell()
        let entry = day!.logEntries[indexPath.row]
        
        cell.textLabel?.text = " Name: \(entry.name)"
        cell.detailTextLabel?.text = "time:\(entry.dateTime)"
        
        return cell*/
        
        let reuseIdentifier = "EntryCell"
        
        var cell:UITableViewCell? = tableView.dequeueReusableCellWithIdentifier(reuseIdentifier)
        if (cell != nil)
        {
            cell = UITableViewCell(style: UITableViewCellStyle.Value1, reuseIdentifier: reuseIdentifier)
        }

        let entry = day!.logEntries[indexPath.row]
        
        cell!.textLabel?.text = "\(entry.name)"
        cell!.detailTextLabel?.text = entry.dateTime.toTimeString()
        
        cell?.textLabel?.textColor = entry.direction == EntryDirection.Entry ? UIColor.greenColor() : UIColor.redColor()
        
        cell?.detailTextLabel?.textColor = UIColor.blackColor()
        return cell!
    }
    
    func tableView(tableView: UITableView, didSelectRowAtIndexPath indexPath: NSIndexPath) {
        tableView.deselectRowAtIndexPath(indexPath, animated: true)
        
        let row = indexPath.row
        
        if let selEntry = day?.logEntries[row] {
            selectedEntry = selEntry
        }
        
        performSegueWithIdentifier("entryDetails", sender: self)
        
    }
    
    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
        if let dest = segue.destinationViewController as? LogEntryViewController {
            
            if (segue.identifier == "entryDetails") {
                dest.isNewScenario = false

            }
            else if (segue.identifier == "newEntry") {
                
                if let date = day?.logEntries.last?.dateTime
                {
                    // TODO: construct dateTime as day date, but current / what time?
                    selectedEntry = LogEntry(id: 0, name: "", direction: EntryDirection.Entry, dateTime: date)
                }
            }
            
            dest.entry = selectedEntry
            
            selectedEntry = nil
        }
    }
    
    override func viewWillTransitionToSize(size: CGSize, withTransitionCoordinator coordinator: UIViewControllerTransitionCoordinator) {
        if UIDevice.currentDevice().orientation.isLandscape.boolValue {
            print("Landscape")
            topStackLayout.axis = UILayoutConstraintAxis.Horizontal
        } else {
            topStackLayout.axis = UILayoutConstraintAxis.Vertical
            print("Portrait")
        }
    }
    
}