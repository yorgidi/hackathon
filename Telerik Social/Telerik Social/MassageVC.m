//
//  MassageVC.m
//  Telerik Social
//
//  Created by Stanimir Karoserov on 07.11.13.
//  Copyright (c) 2013 г. Telerik. All rights reserved.
//

#import "Utils.h"
#import "TimeSlotsVC.h"
#import "MassageVC.h"

@interface MassageVC () <TimeSlotDelegate>

@property (nonatomic, strong) IBOutlet UIButton *refreshButton;
@property (nonatomic, strong) IBOutlet UIButton *selectTimeSlotButton;
@property (nonatomic, strong) IBOutlet UILabel *winLabel;
@property (nonatomic, strong) IBOutlet UILabel *loseLabel;
@property (nonatomic, strong) IBOutlet UILabel *subscribed;

@end

@implementation MassageVC {
    BOOL _willWin;
}

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

- (IBAction)onValueChanged:(UISwitch *)sender
{
    _refreshButton.hidden = !sender.isOn;
    if (sender.isOn) {
        [Utils showAlertWithTitle:@"Thank you!" andMessage:@"Winners will be randomly selected on 11/11/2013.\n\nYou will be notified in case you win :)"];
    }
    else {
        _selectTimeSlotButton.hidden = YES;
        _winLabel.hidden = YES;
        _subscribed.hidden = YES;
        _loseLabel.hidden = YES;
    }
}

- (IBAction)onRefresh:(id)sender
{
    if (_willWin) {
        _winLabel.hidden = NO;
        _subscribed.hidden = YES;
        _loseLabel.hidden = YES;
        _selectTimeSlotButton.hidden = NO;
        _refreshButton.hidden = YES;
    }
    else {
        _winLabel.hidden = YES;
        _subscribed.hidden = YES;
        _loseLabel.hidden = NO;
        _selectTimeSlotButton.hidden = YES;
    }
    _willWin = !_willWin;
}

- (void)onTimeSlotSelected:(NSString *)text
{
    _subscribed.text = text;
    _subscribed.hidden = NO;
    _selectTimeSlotButton.hidden = YES;
    _winLabel.hidden = YES;
}

- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    ((TimeSlotsVC *)segue.destinationViewController).delegate = self;
}

@end
