//
//  TimeSlotsVC.m
//  Telerik Connect
//
//  Created by Stanimir Karoserov on 08.11.13.
//  Copyright (c) 2013 г. Telerik. All rights reserved.
//

#import "TimeSlotsVC.h"

@interface TimeSlotsVC ()

@end

@implementation TimeSlotsVC

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

- (IBAction)onTimeSelect:(UIButton *)sender
{
    if (_delegate) {
        [_delegate onTimeSlotSelected:[NSString stringWithFormat:@"You have your massage time slot reserved for %@ on 12/11/2013", sender.titleLabel.text]];
    }
    [self.navigationController popViewControllerAnimated:YES];
}

- (IBAction)onCannotMakeIt:(id)sender
{
    if (_delegate) {
        [_delegate onTimeSlotSelected:@"You cannot come!"];
    }
    [self.navigationController popViewControllerAnimated:YES];    
}

@end
