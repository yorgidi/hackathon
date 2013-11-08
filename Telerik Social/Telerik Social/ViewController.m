//
//  ViewController.m
//  Telerik Social
//
//  Created by Stanimir Karoserov on 07.11.13.
//  Copyright (c) 2013 г. Telerik. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@property (nonatomic, strong) IBOutlet UIButton* btnPeople;
@property (nonatomic, strong) IBOutlet UIButton* btnMassage;
@property (nonatomic, strong) IBOutlet UIButton* btnLeaves;
@property (nonatomic, strong) IBOutlet UIButton* btnCarPull;
@property (nonatomic, strong) IBOutlet UIButton* btnDailyMenu;

@end

@implementation ViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
	
    [self setupBorder:_btnPeople];
    [self setupBorder:_btnMassage];
    [self setupBorder:_btnLeaves];
    [self setupBorder:_btnCarPull];
    [self setupBorder:_btnDailyMenu];
}

- (void)setupBorder:(UIView *)view
{
    view.layer.borderWidth = 1;
    view.layer.borderColor = [self.view.tintColor CGColor];
    view.layer.cornerRadius = 7;
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
