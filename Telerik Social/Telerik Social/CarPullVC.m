//
//  CarPullVC.m
//  Telerik Social
//
//  Created by Stanimir Karoserov on 07.11.13.
//  Copyright (c) 2013 г. Telerik. All rights reserved.
//

#import "CarPullVC.h"

@interface CarPullVC ()

@property (nonatomic, strong) IBOutlet UILabel* labelHasFreeSeats;
@property (nonatomic, strong) IBOutlet UITextField* textHasFreeSeats;

@end

@implementation CarPullVC

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

- (IBAction)onHasFreeSeats:(UISwitch *)sender
{
    _labelHasFreeSeats.hidden = !sender.isOn;
    _textHasFreeSeats.hidden = !sender.isOn;
}

@end
