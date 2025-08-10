# PPX Interview Tasks

## Project Structure
```
TestPPX/
├── CustomerPPX/
│   ├── Program.cs           
│   └── CustomerPOS.cs       
├── PPX_PromotionEngine/
│   ├── Interfaces/
│   │   └── IDiscountProvider.cs    # Provider contract interface
│   ├── Providers/
│   │   ├── LoyaltyProvider.cs      # Loyalty discount provider
│   │   └── VisaProvider.cs         # Visa discount provider
│   ├── Program.cs                  
│   ├── PromotionEngine.cs          # Discount calculation engine
│   └── PromotionEngine.cs.backup   
└── PPX_Pos/                        
    ├── PassportX_POS.cs            
    └── POS_Process.cs              
```

## Task 1: CustomerPOS
Extended POS welcome message with country-specific greetings.
- **Input**: Country and optional greeting
- **Output**: "Hello Passport-X Italy customer" or "Hola Passport-X Spain customer"
- **Key**: Preserves original generic prefix, extends functionality without overriding

## Task 2: PromotionEngine
Fixed bugs and performance issues in discount calculation system.

### Issues Fixed
- **Logic Bug**: Now applies discounts from any available provider (not just both)
- **Calculation Bug**: Discounts calculated from original price and summed
- **Performance**: Providers created once, item IDs loaded at startup
- **Error Handling**: Provider failures don't crash system
- **Extensibility**: Adding new provider requires only one line of code

### Architecture
- Uses wrapper pattern with IDiscountProvider interface
- Supports Visa and Loyalty providers
- Easily extensible for new providers
- Production-ready with logging and error handling

### Limitations
- Provider APIs only support single-item requests (no batch processing)