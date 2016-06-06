//
//  MonthViewController.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 24/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import UIKit

class MonthViewController: BaseViewController, UITableViewDelegate, UITableViewDataSource {

    var month: Month?

    var selectedDay: Day?
    
    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    

    func tableView(tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return month?.days.count ?? 0
    }
    
    func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
       
        
        let reuseIdentifier = "DayCell"
        
        var cell:UITableViewCell? = tableView.dequeueReusableCellWithIdentifier(reuseIdentifier)
        if (cell != nil)
        {
            cell = UITableViewCell(style: UITableViewCellStyle.Subtitle, reuseIdentifier: reuseIdentifier)
        }
        
        let day = month!.days[indexPath.row]

        cell!.textLabel!.text = day.arrival?.toDateString()
    
        cell!.detailTextLabel!.text = "In Office: \(day.inTime.hour):\(day.inTime.minute):\(day.inTime.second)"
        
        return cell!
    }
    
    func tableView(tableView: UITableView, didSelectRowAtIndexPath indexPath: NSIndexPath) {
        tableView.deselectRowAtIndexPath(indexPath, animated: true)
        
        let row = indexPath.row
        
        if let selDay = month?.days[row] {
            selectedDay = selDay
        }
        
        performSegueWithIdentifier("day", sender: self)
        
    }
    
    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
        if let dest = segue.destinationViewController as? DayViewController {
            dest.day = selectedDay
        }
    }

}
