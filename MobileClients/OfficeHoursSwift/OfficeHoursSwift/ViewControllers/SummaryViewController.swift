//
//  SummaryViewController.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 24/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import UIKit

class SummaryViewController: BaseViewController, UITableViewDelegate, UITableViewDataSource {

    
    var months: [Month]?
    
    var selectedMonth: Month?
    
    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    override func viewWillAppear(animated: Bool) {
        super.viewWillAppear(animated)
        
        months = repository.findAllMonth()
    }
    
    func tableView(tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return months?.count ?? 0
    }

    func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
       /* let cell = MonthCell()
        cell.textLabel?.text = " total seconds: \(months?.first?.averageIn.totalSeconds)"

        return cell
        */
        
        let reuseIdentifier = "MonthCell"
        
        var cell:MonthCell? = tableView.dequeueReusableCellWithIdentifier(reuseIdentifier) as! MonthCell?
        if (cell != nil)
        {
            //cell = UITableViewCell(style: UITableViewCellStyle.Subtitle, reuseIdentifier: reuseIdentifier)
            cell = MonthCell()
        }
        cell!.textLabel!.text = months![indexPath.row].date?.toYearMonthString()
        
        
        return cell!
    }
    
    func tableView(tableView: UITableView, didSelectRowAtIndexPath indexPath: NSIndexPath) {
        tableView.deselectRowAtIndexPath(indexPath, animated: true)
        
        let row = indexPath.row
        
        if let selMonth = months?[row] {
            selectedMonth = selMonth
        }
        
        performSegueWithIdentifier("month", sender: self)
        
    }
    
    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
        if let dest = segue.destinationViewController as? MonthViewController {
            dest.month = selectedMonth
        }
    }
    
}
