//
//  BaseViewController.swift
//  OfficeHoursSwift
//
//  Created by Farkas Marton Imre on 24/05/16.
//  Copyright © 2016 WolferWolfy. All rights reserved.
//

import UIKit

private let sharedRepo = MockRepository()

class BaseViewController: UIViewController {

    class var repository: OfficeHoursRepositoryProtocol {
        return sharedRepo
    }
    static let repository2: OfficeHoursRepositoryProtocol = MockRepository()
    
    var repository: OfficeHoursRepositoryProtocol
    
 //   internal static let repository : OfficeHoursRepositoryProtocol = MockRepository()
    
    required init?(coder aDecoder: NSCoder) {
        repository = RepositoryManager.sharedInstance.repository
        
        super.init(coder: aDecoder)
                
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        // Do any additional setup after loading the view.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }


}
