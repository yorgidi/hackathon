//
//  LeavesVC.m
//  Telerik Social
//
//  Created by Stanimir Karoserov on 07.11.13.
//  Copyright (c) 2013 г. Telerik. All rights reserved.
//

#import "LeavesVC.h"

@interface LeavesVC () <UITableViewDataSource>

@end

@implementation LeavesVC

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view.
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section
{
    return 0;
}

@end
