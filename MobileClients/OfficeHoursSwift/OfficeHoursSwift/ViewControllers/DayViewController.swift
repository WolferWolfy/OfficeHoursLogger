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
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        // Do any additional setup after loading the view.
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
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
            dest.entry = selectedEntry
        }
    }
    
}